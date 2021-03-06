﻿using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
	public class ReadingMessageHeader : BigDdexXml
	{
		[Test]
		public void Message_thread_id_is_read_correctly()
		{
			ddex.Root.MessageHeader.MessageThreadId.should_be_equal_to("MyMessageThreadId");
		}

		[Test]
		public void Message_id_should_be_read_correctly ()
		{
			ddex.Root.MessageHeader.MessageId.should_be_equal_to("MyMessageId");
		}

		[Test]
		public void Message_should_be_an_update_type ()
		{
			ddex.Root.UpdateIndicator.should_be_equal_to("UpdateMessage");
		}

		[Test]
		public void Message_control_type_should_be_Test_Message ()
		{
			ddex.Root.MessageHeader.MessageControlType.should_be_equal_to("TestMessage");
		}

		[Test]
		public void Message_sender_should_be_read_correctly ()
		{
			ddex.Root.MessageHeader.MessageSender.PartyName.FullName.Value.should_be_equal_to("ICanHaz Music Group");
		}
	}
}
