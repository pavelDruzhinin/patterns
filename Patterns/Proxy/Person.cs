namespace Proxy
{
    public class Person
    {

    }

    public interface IPersonBean
    {
        string Name { get; set; }
        string Gender { get; set; }
        string Interests { get; set; }
        int HotOrNotRating { get; set; }
    }

    public class PersonBean : IPersonBean
    {
        private int _rating;
        private int _ratingCount;
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Interests { get; set; }
        public int HotOrNotRating
        {
            get
            {
                if (_ratingCount == 0) return 0;

                return _rating / _ratingCount;
            }
            set
            {
                _rating += value;
                _ratingCount++;
            }
        }
    }

    public class InvocationHandler
    {
        //here code for access to get accessors properties PersonBean using by reflection
    }

    public class NonInvocationsHandler
    {
        //here code for access to set accessors properties PersonBean using by reflection
    }
}