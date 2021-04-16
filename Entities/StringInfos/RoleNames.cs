using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.StringInfos
{
    public enum RoleNamesHelperForView
    {
        Admin,
        Member,
        Moderator,
        Validator,
        Writer
    }
    public static class RoleNames
    {
        public static string Admin { get; set; } = "Admin";
        public static string Member { get; set; } = "Member";
        public static string Moderator { get; set; } = "Moderator";
        public static string Validator { get; set; } = "Validator";
        public static string Writer { get; set; } = "Writer";
    }
}
