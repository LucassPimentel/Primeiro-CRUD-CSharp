using AplicacaoWebCRUD.Models;
using AplicacaoWebCRUD.Models.DTOS;

namespace AplicacaoWebCRUD.Repository
{
    public interface ICarroRepository 
    {

        public bool Add(PostCarro carro);
        public bool Update(PutCarro carro);
        public bool Delete(int id);
        Carro GetCarrosById(int id);
        IEnumerable<Carro> GetCarros();
    }
}
