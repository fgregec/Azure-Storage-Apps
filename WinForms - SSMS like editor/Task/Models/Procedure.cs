using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Dal;

namespace Task.Models
{
    public class Procedure
    {
        private readonly Lazy<IEnumerable<ProcedureParams>> parameters;

        public Procedure()
        {
            parameters = new Lazy<IEnumerable<ProcedureParams>>(() => RepositoryFactory.GetRepository().GetParams(this));
        }

        public IList<ProcedureParams> Parameters
        {
            get => new List<ProcedureParams>(parameters.Value);
        }
        public string Name { get; set; }
        public string Definition { get; set; }
        public Database Database { get; set; }
        public override string ToString() => Name;
    }
}
