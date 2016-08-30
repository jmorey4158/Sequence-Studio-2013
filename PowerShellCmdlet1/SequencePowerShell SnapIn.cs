using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace SequencePowerShell
{
	public class SequencePowerShellModule
	{

        public SequencePowerShellModule() { }
		/// <summary>
		/// Gets description of powershell snap-in.
		/// </summary>
		public string Description
		{
			get { return "The SequencePowerShell console provides access to a subset of the functionality in Sequence Studio® 2013 using Windows PowerShell."; }
		}

		/// <summary>
		/// Gets name of power shell snap-in
		/// </summary>
		public string Name
		{
			get { return "Sequence Studio® 2013 PowerShell Console"; }
		}

		/// <summary>
		/// Gets name of the vendor
		/// </summary>
		public string Vendor
		{
			get { return "Revealed Designs, LLC"; }
		}
	}
}
