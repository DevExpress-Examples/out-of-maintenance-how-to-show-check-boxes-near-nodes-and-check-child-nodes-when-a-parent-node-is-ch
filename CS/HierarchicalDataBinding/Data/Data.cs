// Developer Express Code Central Example:
// How to show check boxes near nodes and check child nodes when a parent node is checked
// 
// Modify our template to add the check edit near a node. Handle checked/unchecked
// events of this check edit and iterate via nodes to check/uncheck child nodes.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3466

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace HierarchicalDataBinding {
    public class BaseObject : INotifyPropertyChanged {
        string nameCore;
        public string Name {
            get { return nameCore; }
            set {
                if (Name == value)
                    return;
                nameCore = value;
                OnPropertyChanged("Name");
            }
        }

        bool? checkedCore = false;
        public bool? Checked {
            get { return checkedCore; }
            set {
                if(Checked == value)
                    return;
                checkedCore = value;
                OnPropertyChanged("Checked");
            }
        }

        String executorCore;
        public String Executor {
            get { return executorCore; }
            set {
                if (ReferenceEquals(Executor, value))
                    return;
                executorCore = value;
                OnPropertyChanged("Executor");
            }
        }

        State stateCore;
        public State State{
            get { return stateCore; }
            set {
                if (ReferenceEquals(State, value))
                    return;
                stateCore = value;
                OnPropertyChanged("State");
            }
        }

        public override string ToString() {
            return Name;
        }

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ProjectObject : BaseObject {
        public ObservableCollection<ProjectStage> Stages { get; set; }
    }

    public class ProjectStage : BaseObject {
        public ObservableCollection<Task> Tasks { get; set; }
    }

    public class Task : BaseObject {
        DateTime startDateCore;
        public DateTime StartDate {
            get { return startDateCore; }
            set {
                if (StartDate == value)
                    return;
                startDateCore = value;
                OnPropertyChanged("StartDate");
            }
        }
        DateTime endDateCore;
        public DateTime EndDate {
            get { return endDateCore; }
            set {
                if (EndDate == value)
                    return;
                endDateCore = value;
                OnPropertyChanged("EndDate");
            }
        }
    }

    public class State : IComparable {
        public ImageSource Image { get; set; }
        public string TextValue { get; set; }
        public int StateValue { get; set; }
        public override string ToString() {
            return TextValue;
        }

        public int CompareTo(object obj) {
            return Comparer<int>.Default.Compare(StateValue, ((State)obj).StateValue);
        }
    }

    public class States : List<State> {
        static List<State> src;
        public static List<State> DataSource {
            get {
                if (src == null) {
                    src = new List<State>();
                    src.Add(new State() { TextValue = "Not started", StateValue = 0});
                    src.Add(new State() { TextValue = "In progress", StateValue = 1});
                    src.Add(new State() { TextValue = "Completed", StateValue = 2 });
                }
                return src;
            }
        }
    }
}