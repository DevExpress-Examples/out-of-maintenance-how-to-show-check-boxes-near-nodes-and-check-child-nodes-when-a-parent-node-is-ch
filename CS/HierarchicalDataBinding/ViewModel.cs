// Developer Express Code Central Example:
// How to show check boxes near nodes and check child nodes when a parent node is checked
// 
// Modify our template to add the check edit near a node. Handle checked/unchecked
// events of this check edit and iterate via nodes to check/uncheck child nodes.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3466

using System;
using System.Collections.ObjectModel;
using System.Collections;
using DevExpress.Xpf.Grid;

namespace HierarchicalDataBinding {
    public class ViewModel {
        public ObservableCollection<ProjectObject> DataItems { get; set; }

        public ViewModel() {
            DataItems = InitData();
        }

        private ObservableCollection<ProjectObject> InitData() {
            ObservableCollection<ProjectObject> projects = new ObservableCollection<ProjectObject>();
            ProjectObject betaronProject = new ProjectObject() { Name = "Project: Betaron", Stages = new ObservableCollection<ProjectStage>() };
            ProjectObject stantoneProject = new ProjectObject() { Name = "Project: Stanton", Stages = new ObservableCollection<ProjectStage>() };

            InitBetaronProjectData(betaronProject);
            InitStantoneProjectData(stantoneProject);

            projects.Add(betaronProject);
            projects.Add(stantoneProject);

            return projects;
        }

        void InitBetaronProjectData(ProjectObject betaronProject) {
            betaronProject.Executor = "Mcfadyen Ball";
            ProjectStage stage21 = new ProjectStage() { Name = "Information Gathering", Executor = "Kaiden Savastano", Tasks = new ObservableCollection<Task>() };

            stage21.Tasks.Add(new Task() { Name = "Market research", Executor = "Carmine Then", StartDate = new DateTime(2011, 10, 1), EndDate = new DateTime(2011, 10, 5), State = States.DataSource[2] });
            stage21.Tasks.Add(new Task() { Name = "Making specification", Executor = "Seto Kober", StartDate = new DateTime(2011, 10, 5), EndDate = new DateTime(2011, 10, 10), State = States.DataSource[1] });
            ProjectStage stage22 = new ProjectStage() { Name = "Planning", Executor = "Manley Difrancesco", Tasks = new ObservableCollection<Task>() };

            stage22.Tasks.Add(new Task() { Name = "Documentation", Executor = "Martez Gollin", StartDate = new DateTime(2011, 10, 15), EndDate = new DateTime(2011, 10, 16), State = States.DataSource[0] });
            ProjectStage stage23 = new ProjectStage() { Name = "Design", Executor ="Clint Mary", Tasks = new ObservableCollection<Task>() };

            stage23.Tasks.Add(new Task() { Name = "Design of a web pages", Executor = "Gasper Hartsell", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });
            stage23.Tasks.Add(new Task() { Name = "Pages layout", Executor = "Shirish Huminski", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });
            ProjectStage stage24 = new ProjectStage() { Name = "Development", Executor = "Edwin Thone", Tasks = new ObservableCollection<Task>() };

            stage24.Tasks.Add(new Task() { Name = "Design", Executor = "Zarko Knill", StartDate = new DateTime(2011, 10, 27), EndDate = new DateTime(2011, 10, 28), State = States.DataSource[0] });
            stage24.Tasks.Add(new Task() { Name = "Coding", Executor = "Harley Kirckof", StartDate = new DateTime(2011, 10, 29), EndDate = new DateTime(2011, 10, 30), State = States.DataSource[0] });
            ProjectStage stage25 = new ProjectStage() { Name = "Testing and Delivery", Executor ="Boucher Hislop", Tasks = new ObservableCollection<Task>() };
            
            stage25.Tasks.Add(new Task() { Name = "Testing", Executor = "Sarah Ragas", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });
            stage25.Tasks.Add(new Task() { Name = "Content", Executor = "Rashid Terinoni", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });

            betaronProject.Stages.Add(stage21);
            betaronProject.Stages.Add(stage22);
            betaronProject.Stages.Add(stage23);
            betaronProject.Stages.Add(stage24);
            betaronProject.Stages.Add(stage25);
        }

        void InitStantoneProjectData(ProjectObject stantoneProject) {
            stantoneProject.Executor = "Ruben Ackerman";
            ProjectStage stage11 = new ProjectStage() { Name = "Information Gathering", Executor = "Huyen Trinklein", Tasks = new ObservableCollection<Task>() };

            stage11.Tasks.Add(new Task() { Name = "Market research", Executor = "Tanner Crittendon", StartDate = new DateTime(2011, 10, 1), EndDate = new DateTime(2011, 10, 5), State = States.DataSource[2] });
            stage11.Tasks.Add(new Task() { Name = "Making specification", Executor = "Carmine Then", StartDate = new DateTime(2011, 10, 5), EndDate = new DateTime(2011, 10, 10), State = States.DataSource[2] });
            ProjectStage stage12 = new ProjectStage() { Name = "Planning", Executor = "Alfredo Sookoo", Tasks = new ObservableCollection<Task>() };

            stage12.Tasks.Add(new Task() { Name = "Documentation", Executor = "Gorf Wobbe", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[2] });

            ProjectStage stage13 = new ProjectStage() { Name = "Design", Executor = "Saphire Plump", Tasks = new ObservableCollection<Task>() };

            stage13.Tasks.Add(new Task() { Name = "Design of a web pages", Executor = "Dominic Minden", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[1] });
            stage13.Tasks.Add(new Task() { Name = "Pages layout", Executor = "Pinkerton Trezise", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[1] });
            ProjectStage stage14 = new ProjectStage() { Name = "Development", Executor = "Lauren Partain", Tasks = new ObservableCollection<Task>() };

            stage14.Tasks.Add(new Task() { Name = "Design", Executor = "Delilah Beamer", StartDate = new DateTime(2011, 10, 23), EndDate = new DateTime(2011, 10, 24), State = States.DataSource[1] });
            stage14.Tasks.Add(new Task() { Name = "Coding", Executor = "Dunaway Dupriest", StartDate = new DateTime(2011, 10, 25), EndDate = new DateTime(2011, 10, 26), State = States.DataSource[0] });
            ProjectStage stage15 = new ProjectStage() { Name = "Testing and Delivery", Executor = "Christos Arrant", Tasks = new ObservableCollection<Task>() };

            stage15.Tasks.Add(new Task() { Name = "Testing", Executor = "Grice Ohora", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });
            stage15.Tasks.Add(new Task() { Name = "Content", Executor = "Christos Arrant", StartDate = new DateTime(2011, 10, 13), EndDate = new DateTime(2011, 10, 14), State = States.DataSource[0] });

            stantoneProject.Stages.Add(stage11);
            stantoneProject.Stages.Add(stage12);
            stantoneProject.Stages.Add(stage13);
            stantoneProject.Stages.Add(stage14);
            stantoneProject.Stages.Add(stage15);
        }
    }

    public class CustomChildrenSelector : IChildNodesSelector {
        public IEnumerable SelectChildren(object item) {
            if (item is Task)
                return null;
            else if (item is ProjectStage)
                return (item as ProjectStage).Tasks;
            else if (item is ProjectObject)
                return (item as ProjectObject).Stages;
            return null;
        }
    }
}