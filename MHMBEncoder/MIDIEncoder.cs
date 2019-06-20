using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHMBEncoder
{
    class MIDIEncoder
    {
        public MIDIEncoder()
        {
            
        }


        public void Encode(string textToEncode, string outputFileName, int keyNoteOctave)
        {
            try
            {
                if (File.Exists(outputFileName))
                {
                    File.Delete(outputFileName);
                }
                EncoderDic encoderDic = new EncoderDic(keyNoteOctave);
                MidiFile midi = new MidiFile();
                TempoMap tempo = midi.GetTempoMap();

                TrackChunk trackChunk = new TrackChunk();
                using (NotesManager notesManager = trackChunk.ManageNotes())
                {
                    int timePos = 0;
                    for (int i = 0; i < textToEncode.Length; i++)
                    {
                        Note note = new Note(encoderDic.GetNoteName(textToEncode[i]), encoderDic.GetOctave(textToEncode[i]), LengthConverter.ConvertFrom(2 * MusicalTimeSpan.Eighth.Triplet(), 0, tempo), timePos);
                        //(Tipo de nota, octava, longitud de la nota, posicion en el tiempo);
                        timePos += 65;
                        notesManager.Notes.Add(note);
                    }
                }
                midi.Chunks.Add(trackChunk);
                midi.Write(outputFileName);
            }catch(IOException)
            {
                Console.WriteLine("[ERROR] Cannot create " + outputFileName + "! Maybe is already used by another process?");
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
