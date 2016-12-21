using System;
using System.Data;
using System.Web.Profile;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for EmployeeContact
/// </summary>
public class EmployeeContact
{
	#region Properties
	private string _EmpId;
	public string EmpId
	{
		get { return _EmpId; }
		set { _EmpId = value; }
	}

	private string _Firstname;
	public string Firstname
	{
		get { return _Firstname; }
		set { _Firstname = value; }
	}

	private string _Lastname;
	public string Lastname
	{
		get { return _Lastname; }
		set { _Lastname = value; }
	}
	#endregion

	public EmployeeContact()
	{
		_EmpId = _Firstname = _Lastname = "";
	}

	public EmployeeContact(string empId, string firstName, string lastName)
	{
		this._EmpId = empId;
		this._Firstname = firstName;
		this._Lastname = lastName;
	}
}

public class EmployeeContacts
{
	private Dictionary<string, EmployeeContact> _Contacts;

	public EmployeeContacts()
	{
		ProfileBase Profile = HttpContext.Current.Profile;
		EmployeeContact[] contacts = (EmployeeContact[])Profile["MyContacts"];
		
		_Contacts = new Dictionary<string, EmployeeContact>();
		if (contacts != null)
		{
			foreach (EmployeeContact c in contacts)
			{
				_Contacts.Add(c.EmpId, c);
			}
		}
	}

	public EmployeeContact[] GetContacts()
	{
		EmployeeContact[] contacts = new EmployeeContact[_Contacts.Values.Count];
		_Contacts.Values.CopyTo(contacts, 0);
		return contacts;
	}

	public void UpdateContact(EmployeeContact contact)
	{
		_Contacts[contact.EmpId] = contact;
		SaveProfile();
	}

	public void InsertContact(EmployeeContact contact)
	{
		if (!_Contacts.ContainsKey(contact.EmpId))
		{
			_Contacts.Add(contact.EmpId, contact);
		}
		SaveProfile();
	}

	public void DeleteContact(EmployeeContact contact)
	{
		_Contacts.Remove(contact.EmpId);
		SaveProfile();
	}

	private void SaveProfile()
	{
		ProfileBase Profile = HttpContext.Current.Profile;
		Profile["MyContacts"] = this.GetContacts();
		Profile.Save();
	}
}
