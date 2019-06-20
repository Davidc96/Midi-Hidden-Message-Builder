using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MHMBDecoder
{
    class MIDIDecoder
    {

        public MIDIDecoder()
        {
            
        }

        public void Decode(string midiFile, int keyNoteOctave)
        {
            try
            {
                DecoderDic ddic = new DecoderDic(keyNoteOctave);
                MidiFile midi = MidiFile.Read(midiFile);
                List<TrackChunk> trackList = midi.GetTrackChunks().ToList();
                string result = "";

                TrackChunk track = trackList[0];
                NotesManager noteManager = track.ManageNotes();

                foreach (Note note in noteManager.Notes)
                {
                    result += ddic.GetChar(note.NoteName, note.Octave);
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("DECODED MIDI FILE MESSAGE: " + result);
                Console.WriteLine("-----------------------------------------");
            }
            catch (IOException)
            {
                Console.WriteLine("[ERROR] Cannot read " + midiFile + "! Maybe is already used by another process?");
                Environment.Exit(-1);
            }
            catch(Exception e)
            {
                Console.WriteLine("[ERROR] Something goes wrong here: " + e.Message);
                Environment.Exit(-1);
            }
            
        }
    }
}
