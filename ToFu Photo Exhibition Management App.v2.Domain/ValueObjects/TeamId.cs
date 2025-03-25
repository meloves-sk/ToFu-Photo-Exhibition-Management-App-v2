using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class TeamId : ValueObject<TeamId>
	{
		public TeamId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(TeamId other)
		{
			return Value == other.Value;
		}
	}
}
