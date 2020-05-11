using System;

namespace timos.data.preventives
{
	public interface IElementADecoupagePourEditeurPreventive
	{
		CDecoupage DecoupageEditeur { get; set;}
		DateTime? DateLimiteEditeur{ get;set;}
		DateTime? DateDebutEditeur{ get;set;}
		CEchelleTemps PeriodiciteOperationPourEditeur{ get;set;}
		int? PeriodiciteOperationCodePourEditeur{ get;set;}
		int? NombreParPeriodePourEditeur { get;set;}
	}
}