using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class ManufacturerId : ValueObject<ManufacturerId>
	{
		public ManufacturerId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(ManufacturerId other)
		{
			return Value == other.Value;
		}
	}
}
