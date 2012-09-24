﻿using System.Collections.Generic;
using System.Linq;
using DDEX_Deserialiser.AutoGenerated;
using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
    [TestFixture]
    public class SoundRecordingTests : BigDdexXml
    {
        private SoundRecording GetFirstRecording()
        {
            return ddex.Root.ResourceList.SoundRecordings.First();
        }

        private TechnicalSoundRecordingDetails GetTechnicalDetails()
        {
            return GetTerritoryDetails().TechnicalSoundRecordingDetails.Single();
        }

        private SoundRecordingDetailsByTerritory GetTerritoryDetails()
        {
            return GetFirstRecording().SoundRecordingDetailsByTerritorys.Single();
        }

        private File GetFile()
        {
            return GetTechnicalDetails().Files.Single();
        }

        [Test]
        public void Should_sound_recording_be_a_musical_work_sound_recording()
        {
            Assert.That(GetFirstRecording().SoundRecordingType.Value, Is.EqualTo("MusicalWorkSoundRecording"));
        }

        [Test]
        public void Should_sound_recording_have_ISRC()
        {
            Assert.That(GetFirstRecording().SoundRecordingIds.Single().ISRC, Is.EqualTo("US82M0754801"));
        }

        [Test]
        public void Should_sound_recording_have_reference()
        {
            Assert.That(GetFirstRecording().ResourceReference, Is.EqualTo("A1"));
        }

        [Test]
        public void Should_sound_recording_have_title()
        {
            Assert.That(GetFirstRecording().ReferenceTitle.TitleText.Value, Is.EqualTo("Destination"));
        }

        [Test]
        public void Should_sound_recording_have_duration()
        {
            Assert.That(GetFirstRecording().Duration, Is.EqualTo("PT5M7.000S"));
        }

        [Test]
        public void Should_sound_recording_details_have_worldwide_territory_code()
        {
            Assert.That(GetTerritoryDetails().TerritoryCodes.Single(), Is.EqualTo("Worldwide"));
        }

        [Test]
        public void Should_sound_recording_detials_have_correct_titles()
        {
            Assert.That(GetTerritoryDetails().Titles.Select(t => t.TitleText.Value), Is.EquivalentTo(new List<string> { "Destination", "Destination" }));
        }

        [Test]
        public void Should_sound_recording_details_have_artist_party_name()
        {
            Assert.That(GetTerritoryDetails().DisplayArtists.Single().PartyNames.Single().FullName.Value, Is.EqualTo("Messages"));
        }

        [Test]
        public void Should_sound_recording_details_have_artist_party_id()
        {
            Assert.That(GetTerritoryDetails().DisplayArtists.Single().PartyId.Value, Is.EqualTo("448566"));
        }

        [Test]
        public void Should_sound_recording_details_have_artist_role()
        {
            Assert.That(GetTerritoryDetails().DisplayArtists.Single().ArtistRoles.Single().Value, Is.EqualTo("MainArtist"));
        }

        [Test]
        public void Should_sound_recording_detials_have_correct_labels()
        {
            Assert.That(GetTerritoryDetails().LabelNames.Select(l=>l.Value), Is.EquivalentTo(new List<string> { "Me Iz Label", "IR A Majr" }));
        }

        [Test]
        public void Should_sound_recording_details_have_Pline()
        {
            Assert.That(GetTerritoryDetails().PLines.Single().Year, Is.EqualTo("2007"));
            Assert.That(GetTerritoryDetails().PLines.Single().PLineText, Is.EqualTo("2007 The Me Iz Label"));
        }

        [Test]
        public void Should_sound_recording_details_have_genre()
        {
            Assert.That(GetTerritoryDetails().Genres.Single().GenreText.Value, Is.EqualTo("Alternative Rock"));
        }

        [Test]
        public void Should_sound_recording_details_have_parental_warning_type()
        {
            Assert.That(GetTerritoryDetails().ParentalWarningTypes.Single().Value, Is.EqualTo("NoAdviceAvailable"));
        }

        [Test]
        public void Should_sound_recording_have_1_technical_detail()
        {
            Assert.That(GetTerritoryDetails().TechnicalSoundRecordingDetails.Count, Is.EqualTo(1));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_reference()
        {
            Assert.That(GetTechnicalDetails().TechnicalResourceDetailsReference, Is.EqualTo("T1"));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_codec_type()
        {
            Assert.That((string)GetTechnicalDetails().AudioCodecType, Is.EqualTo("MP3"));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_bit_rate()
        {
            Assert.That((string)GetTechnicalDetails().BitRate, Is.EqualTo("256"));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_number_of_channels()
        {
            Assert.That(GetTechnicalDetails().NumberOfChannels, Is.EqualTo(2));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_sampling_rate()
        {
            Assert.That((string)GetTechnicalDetails().SamplingRate, Is.EqualTo("44.1"));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_is_preview()
        {
            Assert.That(GetTechnicalDetails().IsPreview, Is.EqualTo(false));
        }

        [Test]
        public void Should_sound_recording_technical_details_have_preview_details()
        {
            Assert.That(GetTechnicalDetails().PreviewDetails.StartPoint, Is.EqualTo("93"));
            Assert.That(GetTechnicalDetails().PreviewDetails.Duration, Is.EqualTo("PT0H2M28.000S"));
            Assert.That(GetTechnicalDetails().PreviewDetails.ExpressionType, Is.EqualTo("Informative"));
        }

        [Test]
        public void Should_sound_recording_file_have_name()
        {
            Assert.That(GetFile().FileName, Is.EqualTo("myfile1.mp3"));
        }

        [Test]
        public void Should_sound_recording_file_have_path()
        {
            Assert.That(GetFile().FilePath, Is.EqualTo("/resources"));
        }

        [Test]
        public void Should_sound_recording_file_have_hash_sum()
        {
            Assert.That((string)GetFile().HashSum.HashSumAlgorithmType, Is.EqualTo("MD5"));
            Assert.That(GetFile().HashSum.HashSumProp, Is.EqualTo("4c342562837456fff325434e325a24cf"));
        }
    }
}
