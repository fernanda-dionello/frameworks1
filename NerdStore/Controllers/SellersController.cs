using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NerdStore.Data;
using NerdStore.Models;
using NerdStore.Models.ViewModel;
using System.Linq;

namespace NerdStore.Controllers
{
    public class SellersController : Controller
    {
        /*Cria uma propriedade referenciando um objeto de conexão com o banco*/
        private readonly NerdStoreContext _context;

        /*Injeção de dependência, sõ vai criar uma instância do controller se tiver
         * um objeto de conexão com o banco como parâmetro*/
        public SellersController(NerdStoreContext context)
        {
            _context = context;
        }

        //A Interface espera uma View como retorno
        public IActionResult Index()
        {
            /*estamos pegando os dados da tabela Seller e adicionando a uma lista,
             * é a mesma coisa que List<Seller> list = new List<Seller>();
             */
            var list = _context.Seller.Include(seller => seller.Department).ToList();
            

            return View(list);
        }

        //Será chamada essa action, quando o usuário acessar a rota /Sellers/Create 
        public IActionResult Create()
        {
            //Criar uma instancia do nosso ViewModel
            var viewModel = new SellerFormViewModel();

            //Acessar o banco de dados e retornar todos os registros de departamentos, adicionando eles nas lista de departamentos do ViewModel
            viewModel.Departments = _context.Department.ToList();

            //Encaminhar a ViewModel com as informações para compilar a view(html)
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            //Vamos atribuir o primeiro departamento do banco ao vendedor
            //seller.Department = _context.Department.FirstOrDefault();

            //Adiciona o vendedor ao banco
            _context.Seller.Add(seller);

            //Confirma a persistencia dos dados
            _context.SaveChanges();

            //Redireciona para o Index
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            //verificar se foi informado um ID na rota
            if(id == null)
            {
                return NotFound();
            }

            //Retorna o vendedor com o ID informado na rota
            //var seller = _context.Seller.FirstOrDefault(seller => seller.Id == id);
            var seller = _context.Seller.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id);

            //Verifica se o vendedor existe
            if(seller == null)
            {
                return NotFound(nameof(seller));
            }

            return View(seller);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _context.Seller.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id);

            if (seller == null)
            {
                return NotFound(nameof(seller));
            }

            return View(seller);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var seller = _context.Seller.Find(id);

            if(seller == null)
            {
                return NotFound();
            }

            _context.Seller.Remove(seller);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
