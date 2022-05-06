using AplicacaoWebCRUD.Models;
using AplicacaoWebCRUD.Models.DTOS;
using AplicacaoWebCRUD.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWebCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _repository;

        public CarroController(ICarroRepository repository)
        {
            _repository = repository;
        }

        public ICarroRepository Repository { get; }

        [HttpGet]
        public IActionResult Get()
        {
            var carros = _repository.GetCarros();
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var carro = _repository.GetCarrosById(id);
            return Ok(carro);
        }

        [HttpPost]
        public ActionResult Post(PostCarro carro)
        {
            return _repository.Add(carro) ? Ok("Criado com sucesso!") : (ActionResult)BadRequest("Ocorreu um erro.");

        }
        [HttpPut]
        public ActionResult Put(PutCarro carro)
        {
            if (_repository.Update(carro))
                return Ok("Atualizado com sucesso!");
            return BadRequest("Ocorreu um erro.");
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(CarroId carro)
        {
            if (_repository.Delete(carro.Id))
                return Ok("Excluído com sucesso!");
            return BadRequest("Ocorreu um erro.");
        }
    }
}
