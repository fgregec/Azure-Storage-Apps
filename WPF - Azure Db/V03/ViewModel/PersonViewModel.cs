using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V03.Dal;
using V03.Models;

namespace V03.ViewModel
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> People { get; }
        
        private SqlRepository sqlRepository;
        public PersonViewModel()
        {
            sqlRepository = RepositoryFactory.GetRepositoryInstance<Person, SqlRepository>();
            People = new ObservableCollection<Person>(sqlRepository.GetAll());
            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    sqlRepository.Add(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    sqlRepository.Delete(e.OldItems.OfType<Person>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    sqlRepository.Update(e.NewItems.OfType<Person>().ToList()[0]);
                    break;
            }

        }
        public void Update(Person person) => People[People.IndexOf(person)] = person;
    }
}
