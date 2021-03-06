﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HRR.Core.Domain.Interfaces
{
    public interface IGoalTemplate
    {
        int ID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int GoalType { get; set; }
        int AccountID { get; set; }
    }
}
