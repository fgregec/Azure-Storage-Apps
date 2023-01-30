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
    public class SubjectViewModel
    {
        public ObservableCollection<Subject> Subjects { get; }

        private SubjectRepository subjectRepository;
        public SubjectViewModel()
        {
            subjectRepository = RepositoryFactory.GetRepositoryInstance<Subject, SubjectRepository>();
            Subjects = new ObservableCollection<Subject>(subjectRepository.GetAll());
            Subjects.CollectionChanged += Subject_CollectionChanged;
        }

        private void Subject_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    subjectRepository.Add(Subjects[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    subjectRepository.Delete(e.OldItems.OfType<Subject>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    subjectRepository.Update(e.NewItems.OfType<Subject>().ToList()[0]);
                    break;
            }

        }
        public void Update(Subject subject) => Subjects[Subjects.IndexOf(subject)] = subject;
    }
}
