namespace Domain.Features.Identity;

public class User :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasOrdering,
	Dtat.Seedwork.Abstractions.IEntityHasIsDeleted,
	Dtat.Seedwork.Abstractions.IEntityHasIsTestData,
	Dtat.Seedwork.Abstractions.IEntityHasIsUndeletable,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	#region Constructor
	///// <summary>
	///// Default Constructor
	///// </summary>
	//public User() : base()
	//{
	//}

	public User(string emailAddress) : base()
	{
		Ordering = 10_000;

		UpdateDateTime = InsertDateTime;

		ResetVerificationKey();
		EmailAddress = emailAddress.ToLower();
	}
	#endregion /Constructor

	#region Properties

	#region public bool IsActive { get; set; }
	/// <summary>
	/// وضعیت
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	#endregion /public bool IsActive { get; set; }

	#region public bool IsTestData { get; set; }
	/// <summary>
	/// داده تستی
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsTestData))]
	public bool IsTestData { get; set; }
	#endregion /public bool IsTestData { get; set; }

	#region public bool IsVerified { get; set; }
	/// <summary>
	/// تایید شده
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsVerified))]
	public bool IsVerified { get; set; }
	#endregion /public bool IsVerified { get; set; }

	#region public bool IsUndeletable { get; set; }
	/// <summary>
	/// غیر قابل حذف
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsUndeletable))]
	public bool IsUndeletable { get; set; }
	#endregion /public bool IsUndeletable { get; set; }

	#region public bool IsProfilePublic { get; set; }
	/// <summary>
	/// پروفایل به صورت عمومی قابل روئت خواهد بود
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsProfilePublic))]
	public bool IsProfilePublic { get; set; }
	#endregion /public bool IsProfilePublic { get; set; }

	#region public bool IsDeleted { get; private set; }
	/// <summary>
	/// آیا به طور مجازی حذف شده؟
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsDeleted))]
	public bool IsDeleted { get; private set; }
	#endregion /public bool IsDeleted { get; private set; }

	#region public bool IsEmailAddressVerified { get; set; }
	/// <summary>
	/// نشانی پست الکترونیکی تایید شده است
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsEmailAddressVerified))]
	public bool IsEmailAddressVerified { get; set; }
	#endregion /public bool IsEmailAddressVerified { get; set; }



	#region public int Ordering { get; set; }
	/// <summary>
	/// چیدمان
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Ordering))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	//[System.ComponentModel.DataAnnotations.Range
	//	(minimum: 1, maximum: 100_000,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public int Ordering { get; set; }
	#endregion /public int Ordering { get; set; }



	#region public string? Username { get; set; }
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Username))]

	//[System.ComponentModel.DataAnnotations.MaxLength
	//	(length: Constants.MaxLength.Username,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Username { get; set; }
	#endregion /public string? Username { get; set; }

	#region public string EmailAddress { get; set; }
	/// <summary>
	/// نشانی پست الکترونیکی
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(Name = "Email Address")]

	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = "EmailAddress")]

	// اگر سوتی بدهم
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = "EmailAdress")]

	// اگر سوتی بدهم
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.EmailAdress))]

	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddress))]

	//[System.ComponentModel.DataAnnotations.Required]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessage = "You did not specify Email Address!")]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessage = "You did not specify {0}!")]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = "Required")]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	//[System.ComponentModel.DataAnnotations.MaxLength
	//	(length: 254)]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.EmailAddress)]

	//[System.ComponentModel.DataAnnotations.MaxLength
	//	(length: Constants.MaxLength.EmailAddress,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	//[System.ComponentModel.DataAnnotations.RegularExpression
	//	(pattern: Constants.RegularExpression.EmailAddress,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string EmailAddress { get; set; }
	//public string? EmailAddress { get; set; }
	#endregion /public string EmailAddress { get; set; }

	#region public string? AdminDescription { get; set; }
	/// <summary>
	/// توضیحات مدیریتی
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.AdminDescription))]
	public string? AdminDescription { get; set; }
	#endregion /public string? AdminDescription { get; set; }

	#region public string? Password { get; private set; }
	/// <summary>
	/// گذرواژه
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Password))]

	//[System.ComponentModel.DataAnnotations.MinLength
	//	(length: Constants.FixedLength.DatabasePassword,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	//[System.ComponentModel.DataAnnotations.MaxLength
	//	(length: Constants.FixedLength.DatabasePassword,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Password { get; private set; }
	#endregion /public string? Password { get; private set; }



	#region public System.Guid EmailAddressVerificationKey { get; private set; }
	/// <summary>
	/// کد تایید نشانی پست الکترونیکی
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.EmailAddressVerificationKey))]
	public System.Guid EmailAddressVerificationKey { get; private set; }
	#endregion /public System.Guid EmailAddressVerificationKey { get; private set; }



	#region public System.DateTimeOffset? LastLoginDateTime { get; set; }
	/// <summary>
	/// آخرین زمان ورود به سامانه
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.LastLoginDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? LastLoginDateTime { get; set; }
	#endregion /public System.DateTimeOffset? LastLoginDateTime { get; set; }

	#region public System.DateTimeOffset UpdateDateTime { get; private set; }
	/// <summary>
	/// زمان ویرایش
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset UpdateDateTime { get; private set; }
	#endregion /public System.DateTimeOffset UpdateDateTime { get; private set; }

	#region public System.DateTimeOffset? DeleteDateTime { get; private set; }
	/// <summary>
	/// زمان حذف مجازی
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.DeleteDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? DeleteDateTime { get; private set; }
	#endregion /public System.DateTimeOffset? DeleteDateTime { get; private set; }

	#region public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }
	/// <summary>
	/// آخرین زمان تغییر گذرواژه
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.LastChangePasswordDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }
	#endregion /public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }

	#endregion /Properties

	#region Methods

	#region Delete()
	public void Delete()
	{
		IsDeleted = true;

		DeleteDateTime =
			Dtat.DateTime.Now;
	}
	#endregion /Delete()

	#region Undelete()
	public void Undelete()
	{
		IsDeleted = false;

		DeleteDateTime = null;
	}
	#endregion /Undelete()

	#region SetPassword()
	public void SetPassword(string? password)
	{
		if (string.IsNullOrWhiteSpace(value: password))
		{
			Password = null;
		}
		else
		{
			var passwordHash = Dtat.Security
				.Hashing.GetSha256(value: password);

			Password = passwordHash;

			LastChangePasswordDateTime = Dtat.DateTime.Now;
		}
	}
	#endregion /SetPassword()

	#region SetUpdateDateTime()
	public void SetUpdateDateTime()
	{
		UpdateDateTime = Dtat.DateTime.Now;
	}
	#endregion /SetUpdateDateTime()

	#region ResetVerificationKey()
	public void ResetVerificationKey()
	{
		EmailAddressVerificationKey = System.Guid.NewGuid();
	}
	#endregion /ResetVerificationKey()

	#endregion /Methods

	#region Collections
	#endregion /Collections
}
