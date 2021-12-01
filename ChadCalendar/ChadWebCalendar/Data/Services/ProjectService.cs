﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChadWebCalendar.Data.Services
{
    public class ProjectService
    {
        ApplicationContext db = new ApplicationContext();
        public Data.Project GetProjectById(int? id)
        {
            if (id != null)
                return db.Projects.FirstOrDefault(p => p.Id == id);
            else
                return null;
        }
        public void UpdateSelectedProject(string UserLogin, int? projectId)
        {
            using (ApplicationContext db = new ApplicationContext()) // обновить выбранный проект
            {
                User user = db.Users.FirstOrDefault(u => u.Login == UserLogin);
                user.SelectedProjectId = projectId;
                db.SaveChangesAsync();
            }
        }
        bool IsCorrect(ref Data.Project project)
        {
            if (project.Name != null && project.Name != "")
                return true;
            else
                return false;
        }
        public IEnumerable<Project> GetProjects(User user)
        {
            return db.Projects.Where(proj => proj.User == user);
        }
        public Data.User GetUser(string Name)
        {
            return db.Users.FirstOrDefault(u => u.Login == Name);
        }

        public bool Create(Project project, string Name)
        {
            User user = db.Users.FirstOrDefault(u => u.Login == Name);
            project.User = user;
            project.Accessed = DateTime.Now;
            if (IsCorrect(ref project))
            {
                db.Projects.Add(project);
                db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public bool Edit(int? id, string Name)
        {
            User user = db.Users.FirstOrDefault(u => u.Login == Name);
            Project project = db.Projects.Include(e => e.User).FirstOrDefault(p => p.Id == id);
            if (IsCorrect(ref project))
            {
                db.Projects.Update(project);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public async void Delete(int? id)
        {
            if (id != null)
            {
                Project project = db.Projects.Include(p=>p.User).FirstOrDefault(p => p.Id == id);
                if (project != null)
                {
                    UpdateSelectedProject(project.User.Login, null);
                    var projectDependencies = db.Tasks.Where(t => t.Project == project);
                    foreach (var item in projectDependencies)
                    {
                        item.Project = null;
                    }
                    db.SaveChanges();
                    db.Projects.Remove(project);
                    db.SaveChanges();
                }
            }
        }
    }
}
