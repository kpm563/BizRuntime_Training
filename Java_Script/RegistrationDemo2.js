function validateForm() {
	var FirstName = document.myForm.First_Name;
	var LastName = document.myForm.Last_Name;
	var BirthdayDay = document.myForm.Birthday_day;
	var BirthdayMonth = document.myForm.Birthday_Month;
	var BirthdayYear = document.myForm.Birthday_Year;
	var EmailId = document.myForm.Email_Id;
	var MobileNumber = document.myForm.Mobile_Number;
	var Gender = document.myForm.Gender;
	var Address = document.myForm.Address;
	var City = document.myForm.City;
	var PinCode = document.myForm.Pin_Code;
	var State = document.myForm.State;
	var Country = document.myForm.Country;
	var Hobbies = document.myForm.Hobbies;
	var Hobby_Other = document.myForm.Hobby_Other;
	var Courses = document.myForm.Courses;

}

function validateFirstName(FirstName) {
	var validName = /^[A-Za-z]+$/;
	if (FirstName.value.match(validName) && FirstName.value.length >= 3 && FirstName.value.length <= 30) {
		return true;
	}
	else {
		alert("Please enter valid first name!");
		FirstName.focus();
		return false;
	}
}

function validateLastName(LastName) {
	var validName = /^[A-Za-z]+$/;
	if (LastName.value.match(validName) && LastName.value.length >= 3 && LastName.value.length <= 30) {
		return true;
	}
	else {
		alert("Please enter valid first name!");
		LastName.focus();
		return false;
	}
}

function validateBirthdayDay(BirthdayDay, BirthdayMonth, BirthdayYear) {
	if (BirthdayYear.value % 400 == 0 || BirthdayYear.value % 4 == 0) {
		if (BirthdayMonth == 2) {
			if (BirthdayDay.value >= 1 && BirthdayDay.value <= 29) {
				return true;
			}
			else {
				alert("Please select a valid date!");
				BirthdayDay.focus();
				return false;
			}
		}
	}
	
	if (BirthdayMonth.value == 4 || BirthdayMonth.value == 6 || BirthdayMonth.value == 9 || BirthdayMonth.value == 11) {
		if (BirthdayDay.value >= 1 && BirthdayDay.value <= 30) {
			return true;
		}
		else {
			alert("Please select a valid date!");
			BirthdayDay.focus();
			return false;
		}
	}
	else if (BirthdayMonth.value == 1 || BirthdayMonth.value == 3 || BirthdayMonth.value == 5 || BirthdayMonth.value == 7 || BirthdayMonth.value == 8 || BirthdayMonth.value == 10 || BirthdayMonth.value == 12) {
		if (BirthdayDay.value >= 1 && BirthdayDay.value <= 31) {
			return true;
		}
		else {
			alert("Please select a valid date!");
			BirthdayDay.focus();
			return false;
		}
	}
	else if (BirthdayMonth.value == 2) {
		if (BirthdayDay.value >= 1 && BirthdayDay.value <= 28) {
			return true;
		}
		else {
			return false;
		}
	}
}

function validateBirthdayMonth(BirthdayMonth) {
	if (BirthdayMonth.value >= 1 && BirthdayMonth.value <= 12) {
		return true;
	}
	else {
		alert("Please select a valid Month!");
		BirthdayMonth.focus();
		return false;
	}
}

function validateBirthdayYear(BirthdayYear) {
	if (BirthdayYear.value >= 1980 && BirthdayYear.value <= 2012) {
		return true;
	}
	else {
		alert("Please select a valid Year!");
		BirthdayYear.focus();
		return false;
	}
}

function validateEmailId(EmailId) {
	var email = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
	if (EmailId.value.match(email) && EmailId.value.length <= 100) {
		return true;
	}
	else {
		alert("Enter a valid E-mail address!");
		EmailId.focus();
		return false;
	}
}

function validateMobileNumber(MobileNumber) {
	if (MobileNumber.value.length == 10) {
		return true;
	}
	else {
		alert("Enter a valid 10 digit mobile number!");
		MobileNumber.focus();
		return false;
	}			
}

function validateGender(Gender) {
	var flag = true;
	for (var i = 0; i < Gender.length; i++) {
		if (Gender[i].checked) {
			flag = false;
			break;
		}
		if (flag) {
			alert("Plaese select your gender");
			Gender[0].focus();
			return false;
		}
		else {
			return true;
		}
	}
}

function validateAddress(Address) {
	if (Address.value.length < 5) {
		alert("Please enter a valid address!");
		Address.focus();
		return false;
	}
	else {
		return true;
	}
}

function validateCity(City) {
	var validCity = /^[A-Za-z]+$/;
	if (City.value.match(validCity) && City.value.length >= 3 && City.value.length <= 30) {
		return true;
	}
	else {
		alert("Please enter valid City name!");
		FirstName.focus();
		return false;
	}
}

function validatePinCode(PinCode) {
	var validPin = /^[0-9]+$/;
	if (PinCode.value.match(validPin) && PinCode.value.length == 6) {
		return true;
	}
	else {
		alert("Please enter valid PIN Code!");
		PinCode.focus();
		return false;
	}
}

function validateState(State) {
	var validState = /^[A-Za-z]+$/;
	if (State.value.match(validState) && State.value.length >= 3 && State.value.length <= 30) {
		return true;
	}
	else {
		alert("Please enter valid first name!");
		FirstName.focus();
		return false;
	}
}

function validateHobbies(Hobbies) {
	for (var i = 0; i < Hobbies.value.length)
}

function validateHobby_Other(Hobby_Other) { }
function validateCourses(Courses) { }