using System;
using Prism.Mvvm;

namespace Sautom.Client.Modules.Client.Controls.ViewModels
{
    public class ClientInfoEditorViewModel : BindableBase
    {
	    #region Proposal properties

	    public Guid Id { get; set; }

	    private string _nameLat;

	    public string NameLat
        {
            get { return _nameLat; }
            set
            {
                _nameLat = value;
                OnPropertyChanged(() => NameLat);
            }
        }

	    private string _personalNumber;

	    public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                _personalNumber = value;
                OnPropertyChanged(() => PersonalNumber);
            }
        }

	    private string _firstName;

	    public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;//.EnsureOnlyCyrillicLetters();
                OnPropertyChanged(() => FirstName);
            }
        }

	    private string _lastName;

	    public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;//.EnsureOnlyCyrillicLetters();
                OnPropertyChanged(() => LastName);
            }
        }

	    private string _middleName;

	    public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;//.EnsureOnlyCyrillicLetters();
                OnPropertyChanged(() => MiddleName);
            }
        }

	    private DateTime? _birthDate;

	    public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(() => BirthDate);
                OnPropertyChanged(() => IsParentSection);
            }
        }

	    private string _passportInfo;

	    public string PassportInfo
        {
            get { return _passportInfo; }
            set
            {
                _passportInfo = value;//.EnsureOnlyLatinicLettersAndNumbers();
                OnPropertyChanged(() => PassportInfo);
            }
        }

	    private string _passportByWhom;

	    public string PassportByWhom
        {
            get { return _passportByWhom; }
            set
            {
                _passportByWhom = value;
                OnPropertyChanged(() => PassportByWhom);
            }
        }

	    private DateTime? _passportFromDate;

	    public DateTime? PassportFromDate
        {
            get { return _passportFromDate; }
            set
            {
                _passportFromDate = value;
                OnPropertyChanged(() => PassportFromDate);
            }
        }

	    private DateTime? _passportByDate;

	    public DateTime? PassportByDate
        {
            get { return _passportByDate; }
            set
            {
                _passportByDate = value;
                OnPropertyChanged(() => PassportByDate);
            }
        }

	    private string _address;

	    public string Address
        {
            get { return _address; }
            set
            {
                _address = value;//.EnsureOnlyCyrillicLettersAndNumbersAndSeparators();
                OnPropertyChanged(() => Address);
            }
        }

	    private string _phoneFirst;

	    public string PhoneFirst
        {
            get { return _phoneFirst; }
            set
            {
                _phoneFirst = value;
                OnPropertyChanged(() => PhoneFirst);
            }
        }

	    private string _phoneSecond;

	    public string PhoneSecond
        {
            get { return _phoneSecond; }
            set
            {
                _phoneSecond = value;
                OnPropertyChanged(() => PhoneSecond);
            }
        }

	    //parent section
	    private string _parentName;

	    public string ParentName
        {
            get { return _parentName; }
            set
            {
                _parentName = value;
                OnPropertyChanged(() => ParentName);
            }
        }

	    private string _parentAddress;

	    public string ParentAddress
        {
            get { return _parentAddress; }
            set
            {
                _parentAddress = value;
                OnPropertyChanged(() => ParentAddress);
            }
        }

	    private string _parentPhone;

	    public string ParentPhone
        {
            get { return _parentPhone; }
            set
            {
                _parentPhone = value;
                OnPropertyChanged(() => ParentPhone);
            }
        }

	    private string _parentPassportInfo;

	    public string ParentPassportInfo
        {
            get { return _parentPassportInfo; }
            set
            {
                _parentPassportInfo = value;
                OnPropertyChanged(() => ParentPassportInfo);
            }
        }

	    public bool IsParentSection
        {
            get
            {
                return BirthDate.HasValue && Math.Abs(BirthDate.Value.Date.Year - DateTime.Now.Date.Year) < 18;
            } //todo BL detected
        }

	    private bool _isFirstNameError;

	    public bool IsFirstNameError
        {
            get { return _isFirstNameError; }
            set 
            {
                _isFirstNameError = value;
                OnPropertyChanged(() => IsFirstNameError);
            }
        }

	    private bool _isMiddleNameError;

	    public bool IsMiddleNameError
        {
            get { return _isMiddleNameError; }
            set
            {
                _isMiddleNameError = value;
                OnPropertyChanged(() => IsMiddleNameError);
            }
        }

	    private bool _isLastNameError;

	    public bool IsLastNameError
        {
            get { return _isLastNameError; }
            set
            {
                _isLastNameError = value;
                OnPropertyChanged(() => IsLastNameError);
            }
        }

	    #endregion
    }
}
