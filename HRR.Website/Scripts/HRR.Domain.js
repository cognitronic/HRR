function CurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = mm + '/' + dd + '/' + yyyy + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    return today;
}

function dateToWcf(input) {
    var d = new Date(input);
    if (isNaN(d)) return null;
    return '\/Date(' + d.getTime() + '-0000)\/';
}

function Goal() {
    this.DueDate = dateToWcf(CurrentDate());
    this.Title = "";
    this.Description = "";
    this.ID = 0;
    this.DateCreated = dateToWcf(CurrentDate());
    this.EnteredFor = 0;
    this.IsApproved = false;
    this.IsAccepted = false;
    this.Score = 0;
    this.GoalType = 0;
    this.StatusID = 0;
    this.Progress = 0;
    this.ReviewID = 0;
    this.AccountID = 0;
    this.ManagerEvaluation = "";
    this.EmployeeEvaluation = "";
    this.ChangedBy = 0;
    this.EnteredBy = 0;
    this.LastUpdated = dateToWcf(CurrentDate());
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
    this.Weight;
    this.Milestones = [];
    this.Managers = [];
}

function GoalWeight() {
    this.Title = "";
    this.ID = 0;
    this.Weight = 0;
}

function GoalManager()
{
    this.RecievesNotifications = true;
    this.PersonID = 0;
    this.GoalID = 0;
    this.ID = 0;
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
}

function GoalMilestone() {
    this.DueDate = dateToWcf(CurrentDate());
    this.Title = "";
    this.Description = "";
    this.GoalID = 0;
    this.ID = 0;
    this.IsAccepted = false;
    this.DateCreated = dateToWcf(CurrentDate());
    this.EnteredBy = 0;
    this.EnteredFor = 0;
    this.Status = 0;
    this.AccountID = 0;
    this.ChangedBy = 0;
    this.LastUpdated = dateToWcf(CurrentDate());
    this.ManagerEvaluation = "";
    this.EmployeeEvaluation = "";
    this.IsComplete = false;
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
}

function Person() {
    this.ID = 0;
    this.Email = "";
    this.FirstName = "";
    this.LastName = "";
    this.Password = "";
    this.UserName = "";
    this.Title = "";
    this.HireDate = dateToWcf(CurrentDate());
    this.TerminationDate = dateToWcf(CurrentDate());
    this.ManagerID = 0;
    this.RoleID = 0;
    this.DepartmentID = 0;
    this.AvatarPath = "";
    this.IsActive = true;
    this.ReceiveCommentNotifications = true;
    this.MarkedForDeletion = false;
    this.AccountID = 0;
    this.Birthdate = dateToWcf(CurrentDate());
    this.FacebookPath = "";
    this.TwitterPath = "";
    this.LinkedInPath = "";
    this.IsManager = false;
    this.PasswordQuestion = "";
    this.PasswordAnswer = "";
    this.ChangedBy = 0;
    this.EnteredBy = 0;
    this.DateCreated = dateToWcf(CurrentDate());
    this.LastUpdated = dateToWcf(CurrentDate());
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
    this.AcceptedTerms = false;
    this.DateAcceptedTerms = dateToWcf(CurrentDate());
    this.Reviews = [];
    this.Documents = [];
    this.Absences = [];
    this.Memberships = [];
    this.Goals = [];
    this.Teammates = [];
    this.Memberships = [];
}

function TeamMember() {
    this.ID = 0;
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
    this.TeamID = 0;
    this.PersonID = 0;
    this.IsActive = true;
    this.RecievesNotifications = true;
    this.IsManager = false;
    this.HasAccess = true;
}

function Review() {
    this.ID = 0;
    this.TypeOfItem = "";
    this.ItemReference = "";
    this.Name = "";
    this.Title = "";
    this.StartDate = dateToWcf(CurrentDate());
    this.DueDate = dateToWcf(CurrentDate());
    this.EnteredFor = 0;
    this.IsActive = true;
    this.EnteredBy = 0;
    this.DateCreated = dateToWcf(CurrentDate());
    this.Goals = [];
    this.Notes = [];
    this.Managers = [];
    this.ReviewQuestionScores = [];
    this.Status = 0;
    this.Score = 0;
    this.ReviewTemplateID = 0;
    this.AccountID = 0;
    this.IsCurrent = true;
    this.ChangedBy = 0;
    this.LastUpdated = dateToWcf(CurrentDate());
}

function ReviewSetup() {
    this.StartDate = dateToWcf(CurrentDate());
    this.DueDate = dateToWcf(CurrentDate());
    this.TemplateID = 0;
}