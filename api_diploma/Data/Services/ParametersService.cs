using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;
using System.Reflection.Metadata;
using Parameter = api_diploma.Data.Models.Parameter;

namespace api_diploma.Data.Services
{
    public class ParametersService
    {
        AppDbContext _context;
        public ParametersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddParameter(ParameterVM parameter)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == parameter.PersonId);

            if (_person != null)
            {
                var _parameter = new Parameter()
                {
                    Height = parameter.Height,
                    Width = parameter.Width,
                    ShoeSize = parameter.ShoeSize,
                    ClothingSize = parameter.ClothingSize,
                    GasMaskSize = parameter.GasMaskSize,
                    HeadCircumference = parameter.HeadCircumference,
                    Person = _person
                };

                _context.Parameter.Add(_parameter);
                _context.SaveChanges();
            }
        }

        public List<Parameter> GetAllParameters() => _context.Parameter.ToList();

        public Parameter GetParameterById(int id) => _context.Parameter.FirstOrDefault(p => p.Id == id);

        public List<Parameter> GetParametersByPersonId(int id) => _context.Parameter.Where(p => p.PersonId == id).ToList();

        public Parameter UpdateParameterById(int id, ParameterVM parameter)
        {
            var _parameter = _context.Parameter.FirstOrDefault(p => p.Id == id);

            if (_parameter != null)
            {
                _parameter.Height = parameter.Height;
                _parameter.Width = parameter.Width; 
                _parameter.ShoeSize = parameter.ShoeSize;
                _parameter.ClothingSize = parameter.ClothingSize;
                _parameter.GasMaskSize = parameter.GasMaskSize;
                _parameter.HeadCircumference = parameter.HeadCircumference;

                _context.SaveChanges();
            }

            return _parameter;
        }

        public void DeleteParameterById(int id)
        {
            var _parameter = _context.Parameter.FirstOrDefault(p => p.Id == id);
            if (_parameter != null)
            {
                _context.Parameter.Remove(_parameter);
                _context.SaveChanges();
            }
        }
    }
}
