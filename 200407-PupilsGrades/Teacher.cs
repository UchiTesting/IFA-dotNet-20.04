namespace PupilsGrades
{
    public class Teacher
    {
        public string Name { get; set; }

        public Teacher(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Teacher)))
            {
                Teacher tmp = ((Teacher) obj);
                if (tmp.Name.Equals(this.Name))
                    return true;
            }
            
            return false;
        }
    }
}