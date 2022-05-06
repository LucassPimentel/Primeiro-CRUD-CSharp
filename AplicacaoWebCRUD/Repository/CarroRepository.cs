using AplicacaoWebCRUD.Models;
using AplicacaoWebCRUD.Models.DTOS;

namespace AplicacaoWebCRUD.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext context;

        public CarroRepository(AppDbContext _context)
        {
            context = _context;
        }


        public bool Delete(int id)
        {
            try
            {
                var carro_db = context.Carro.Find(id);
                context.Carro.Remove(carro_db);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Carro> GetCarros()
        {
            var carros = context.Carro.ToList();
            return carros;

        }

        public Carro GetCarrosById(int id)
        {
            try
            {
                var carro = context.Carro.Find(id);
                return carro;
            }
            catch
            {
                throw new BadHttpRequestException("Erro em GetCarrosById");
            }

        }

        public bool Add(PostCarro carro)
        {

            try
            {
                var novoCarro = new Carro
                {
                    Nome = carro.Nome,
                    Marca = carro.Marca,
                    Potencia = carro.Potencia
                };
                context.Carro.Add(novoCarro);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(PutCarro carro)
        {
            try
            {
                var carro_db = context.Carro.Find(carro.Id);
                carro_db.Nome = carro.Nome;
                carro_db.Marca = carro.Marca;
                carro_db.Potencia = carro.Potencia;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
