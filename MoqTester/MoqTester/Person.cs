namespace MoqTester
{
    public class Person : IPerson
    {
        #region Constructors And Destructors

        public Person(IPersonDataService personDataService)
        {
            _dataservice = personDataService;

            HairColor = _dataservice.GetHairColor();
        }

        #endregion

        #region Properties

        public string FirstName { get; set; }

        public string HairColor { get; set; }

        public string LastName { get; set; }

        #endregion

        #region Methods

        public void DoMakeOver()
        {
            HairColor = "Red";
            _dataservice.UpdatePersonInfo(HairColor);
        }

        #endregion

        #region Fields

        private readonly IPersonDataService _dataservice;

        #endregion
    }

    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void DoMakeOver();
    }

    public interface IPersonDataService
    {
        #region Methods

        string GetHairColor();

        void UpdatePersonInfo(string hairColor);

        #endregion
    }


    public class PersonTestDataService : IPersonDataService
    {
        #region Constructors And Destructors

        public PersonTestDataService(string hairColor)
        {
            _currentHairColor = hairColor;
        }

        #endregion

        #region Methods

        public string GetHairColor()
        {
            return _currentHairColor;
        }

        public void UpdatePersonInfo(string hairColor)
        {
            //do nothing
        }

        #endregion

        #region Fields

        private readonly string _currentHairColor;

        #endregion
    }

    public class PersonDataService : IPersonDataService
    {
        #region Methods

        public string GetHairColor()
        {
            //read from DB, for example

            return "Black";
        }

        public void UpdatePersonInfo(string hairColor)
        {
            //write to DB, for example
        }

        #endregion
    }
}