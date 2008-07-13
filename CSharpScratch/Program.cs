using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClrExtensions;
using ClrExtensions.Win32.Http;

namespace CSharpScratch
{
	class Program
	{
		static void Main(string[] args)
		{
			using (HttpApiConfigContext context = new HttpApiConfigContext())
			{

				context.SetUrlAcl("http://+:8016/", new UrlAcl(new UrlAce("RADICALJAY", "fourthmonth", UrlPermission.Registration)));

				context.SetUrlAcl("http://+:8017/", new UrlAcl(new UrlAce("RADICALJAY", "fourthmonth", UrlPermission.Registration), new UrlAce("RADICALJAY\\Grauenwolf", UrlPermission.Delegation ^ UrlPermission.Registration)));

				var x = context.QueryUrlAcl();
				foreach (var key in x.Keys)
				{
					Console.WriteLine(key);
				}

				context.DeleteUrlAcl("http://+:8016/");
				context.DeleteUrlAcl("http://+:8017/");


				//var config = new UrlAclConfigItem();
				//config.Dacl = new Acl();
				//config.Url = "http://+:8080/";

				//var ace = new Ace("RADICALJAY\\fourthmonth", true  , UrlPermission.Registration,null);
				//config.Dacl.Aces.Add(ace);
				//config.ApplyConfig();
				////                "RADICALJAY\\fourthmonth"		
			}

		}
	}

}
