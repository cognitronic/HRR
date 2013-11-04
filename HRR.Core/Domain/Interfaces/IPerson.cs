﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerson : IItem, IAuditable
    {
        string Email { get; set; }
        bool IsActive { get; set; }
        bool ReceiveCommentNotifications { get; set; }
        string Title { get; set; }
        DateTime? HireDate { get; set; }
        DateTime? TerminationDate { get; set; }
        int ManagerID { get; set; }
        int RoleID { get; set; }
        int DepartmentID { get; set; }
        string AvatarPath { get; set; }
        bool MarkedForDeletion { get; set; }
        int AccountID { get; set; }
        IList<Person> Teammates { get; set; }
        IList<TeamMember> Memberships { get; set; }
        IList<Absence> Absences { get; set; }
        IList<Goal> Goals { get; set; }
        IList<Document> Documents { get; set; }
        Person Manager { get; set; }
        DateTime? Birthdate { get; set; }
        string FacebookPath { get; set; }
        string TwitterPath { get; set; }
        string LinkedInPath { get; set; }
        Department DepartmentRef { get; set; }
        bool IsManager { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        bool AcceptedTerms { get; set; }
        DateTime? DateAcceptedTerms { get; set; }
    }
}