﻿using System.Xml.Linq;
using DDEX_Deserialiser.autogenerated;

namespace DDEX_Deserialiser
{
	public class DDEX
	{
		public readonly NewReleaseMessage root;

		public DDEX(string sourceFilePath)
		{
			var XDoc = XDocument.Load(sourceFilePath);
			root = new NewReleaseMessage(XDoc.Root);
		}
	}
}