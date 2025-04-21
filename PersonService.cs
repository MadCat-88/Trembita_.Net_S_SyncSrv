using CoreWCF;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PersonApi_sync_SOAP
{
    [DataContract]
    public class PersonItem
    {
        public enum GenderEnum
        {
            male,
            female
        }
        [DataMember]
        [Required]
        public string Name { set; get; } = string.Empty;
        [DataMember]
        [Required]
        public string Surname { set; get; } = string.Empty;
        [DataMember]
        public string? Patronym { set; get; }
        [DataMember]
        public DateTime DateOfBirth { set; get; }
        [DataMember]
        public GenderEnum Gender { set; get; }
        [DataMember]
        public string? Rnokpp { set; get; }
        [DataMember]
        public string? PassportNumber { set; get; }
        [DataMember]
        [Required]
        public string Unzr { init; get; } = string.Empty;
        [DataMember]
        public DateTime Inserted { get; init; }
        [DataMember]
        public DateTime LastUpdated { get; set; }
    }

    [MessageContract]
    public class PersonResponse
    {
        [MessageBodyMember]
        public PersonItem Person;
    }

    [MessageContract]
    public class PersonsListResponse
    {
        [MessageBodyMember]
        public List<PersonItem> Persons;
    }

    [MessageContract]
    public class PersonSmallRequest
    {
        [MessageBodyMember]
        [Required]
        public string unzr;
    }

    [MessageContract]
    public class TextResponse
    {
        [MessageBodyMember]
        public string result;
    }

    [MessageContract]
    public class PersonFullRequest
    {
        [MessageBodyMember]
        [Required]
        public string Name;
        [MessageBodyMember]
        [Required]
        public string Surname;
        [MessageBodyMember]
        public string? Patronym;
        [MessageBodyMember]
        public DateTime DateOfBirth;
        [MessageBodyMember]
        public PersonItem.GenderEnum Gender;
        [MessageBodyMember]
        public string? Rnokpp;
        [MessageBodyMember]
        public string? PassportNumber;
        [MessageBodyMember]
        [Required]
        public string Unzr;
    }

    [MessageContract]
    public class PersonFullResponce
    {
        [MessageBodyMember]
        public string Name;
        [MessageBodyMember]
        public string Surname;
        [MessageBodyMember]
        public string? Patronym;
        [MessageBodyMember]
        public DateTime DateOfBirth;
        [MessageBodyMember]
        public PersonItem.GenderEnum Gender;
        [MessageBodyMember]
        public string? Rnokpp;
        [MessageBodyMember]
        public string? PassportNumber;
        [MessageBodyMember]
        public string Unzr;
        [MessageBodyMember]
        public DateTime Inserted;
        [MessageBodyMember]
        public DateTime LastUpdated;
    }

    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract(Action = "Read person", Name = "ReadPerson")]
        [FaultContract(typeof(string))]
        PersonFullResponce GetPerson(PersonSmallRequest Req);

        [OperationContract(Action = "Update person", Name = "UpdatePerson")]
        [FaultContract(typeof(string))]
        PersonFullResponce UpdatePerson(PersonFullRequest Req);

        [OperationContract(Action = "Delete person", Name = "DeletePerson")]
        [FaultContract(typeof(string))]
        TextResponse DeletePerson(PersonSmallRequest Req);

        [OperationContract(Action = "Create person", Name = "CreatePerson")]
        [FaultContract(typeof(string))]
        PersonFullResponce CreatePersons(PersonFullRequest Req);

        [OperationContract(Action = "List persons", Name = "ListAll")]
        [FaultContract(typeof(string))]
        PersonsListResponse GetPersonsList();
    }

    public class PersonService : IPersonService
    {
        private static List<PersonItem> _context = new();

        public PersonFullResponce GetPerson(PersonSmallRequest Req)
        {
            PersonFullResponce r = new();
            foreach (PersonItem item in _context)
            {
                if (item.Unzr == Req.unzr)
                {
                    r.Unzr = Req.unzr;
                    r.Name = item.Name;
                    r.Surname = item.Surname;
                    r.Patronym = item.Patronym;
                    r.DateOfBirth = item.DateOfBirth;
                    r.Gender = item.Gender;
                    r.Rnokpp = item.Rnokpp;
                    r.PassportNumber = item.PassportNumber;
                    r.Inserted = item.Inserted;
                    r.LastUpdated = item.LastUpdated;
                }
            }
            return r;
        }

        public PersonFullResponce UpdatePerson(PersonFullRequest Req)
        {
            PersonFullResponce r = new();
            foreach (PersonItem item in _context)
            {
                if (item.Unzr == Req.Unzr)
                {
                    r.Unzr = Req.Unzr;
                    item.Name = Req.Name; r.Name = item.Name;
                    item.Surname = Req.Surname; r.Surname = item.Surname;
                    item.Patronym = Req.Patronym; r.Patronym = item.Patronym;
                    item.DateOfBirth = Req.DateOfBirth; r.DateOfBirth = item.DateOfBirth;
                    item.Gender = Req.Gender; r.Gender = item.Gender;
                    item.Rnokpp = Req.Rnokpp; r.Rnokpp = item.Rnokpp;
                    item.PassportNumber = Req.PassportNumber; r.PassportNumber = item.PassportNumber;
                    r.Inserted = item.Inserted;
                    item.LastUpdated = DateTime.Now; r.LastUpdated = item.LastUpdated;
                }
            }
            return r;
        }

        public TextResponse DeletePerson(PersonSmallRequest Req)
        {
            List<PersonItem> r = new() {
                new PersonItem() {
                    Name = "TestName",
                    Surname = "TestSurname",
                    Unzr = "19910824-00026",
                    Inserted = DateTime.Now,
                    LastUpdated = DateTime.Now
                }
            };
            foreach (PersonItem item in _context)
            {
                if (item.Unzr != Req.unzr) { r.Add(item); continue; }
            }
            _context = r;
            return new TextResponse()
            {
                result = _context.Count.ToString()
            };
        }

        public PersonFullResponce CreatePersons(PersonFullRequest Req)
        {
            _context.Add(new PersonItem()
            {
                Name = Req.Name,
                Surname = Req.Surname,
                Patronym = Req.Patronym,
                DateOfBirth = Req.DateOfBirth,
                Gender = Req.Gender,
                Rnokpp = Req.Rnokpp,
                PassportNumber = Req.PassportNumber,
                Unzr = Req.Unzr,
                Inserted = DateTime.Now,
                LastUpdated = DateTime.Now
            });
            return new PersonFullResponce()
            {
                Name = Req.Name,
                Surname = Req.Surname,
                Patronym = Req.Patronym,
                DateOfBirth = Req.DateOfBirth,
                Gender = Req.Gender,
                Rnokpp = Req.Rnokpp,
                PassportNumber = Req.PassportNumber,
                Unzr = Req.Unzr,
                Inserted = DateTime.Now,
                LastUpdated = DateTime.Now
            };
        }

        public PersonsListResponse GetPersonsList()
        {
            return new PersonsListResponse() { Persons = _context };
        }
    }
}

