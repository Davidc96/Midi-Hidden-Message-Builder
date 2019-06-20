using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHMBDecoder
{
    class DecoderDic
    {
        public static int INIT_OCTAVE = 2;
        private static int MAX_OCTAVE = 11; //<-- DON'T TOUCH IT
        struct NoteOctave
        {
            public int id; //<-- NOT USED BUT NEEDED IN ORDER TO CREATE UNIQUE KEYS
            public NoteName note;
            public int octave;
        }
        private Dictionary<NoteOctave, char > noteEncoderDictionary;

        public DecoderDic(int keyNoteOctave)
        {
            noteEncoderDictionary = new Dictionary<NoteOctave, char>();
            InitDictionary(keyNoteOctave);
        }

        private void InitDictionary(int keyNoteOctave)
        {
            string charset = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!? ,.";
            Console.WriteLine("[INFO] Number of characters in dic: " + charset.Length);
            int noteCounter = 0;
            int octaveCounter = keyNoteOctave % MAX_OCTAVE;

            for (int i = 0; i < charset.Length; i++)
            {
                NoteOctave n = new NoteOctave();
                switch (noteCounter)
                {
                    case 0:
                        n.note = NoteName.C;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 1:
                        n.note = NoteName.CSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 2:
                        n.note = NoteName.D;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 3:
                        n.note = NoteName.DSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 4:
                        n.note = NoteName.E;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 5:
                        n.note = NoteName.F;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 6:
                        n.note = NoteName.FSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 7:
                        n.note = NoteName.G;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 8:
                        n.note = NoteName.GSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 9:
                        n.note = NoteName.A;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 10:
                        n.note = NoteName.ASharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    case 11:
                        n.note = NoteName.B;
                        n.octave = octaveCounter;
                        noteCounter++;
                        n.id = i;
                        noteEncoderDictionary.Add(n, charset[i]);
                        break;
                    default:
                        noteCounter = 0;
                        octaveCounter++;
                        octaveCounter = octaveCounter % MAX_OCTAVE;
                        Console.WriteLine("[INFO] OctaveCounter = " + octaveCounter);

                        i -= 1; //Repeat the loop iteration
                        break;
                }



            }

            Console.WriteLine("[INFO] Loaded Decoder Dictionary");
        }

        public char GetChar(NoteName note, int octave)
        {
            foreach(NoteOctave noteOctave in noteEncoderDictionary.Keys)
            {
                if((noteOctave.note == note) && (noteOctave.octave == octave))
                {
                    return noteEncoderDictionary[noteOctave];
                }
            }

            return '#';
        }

    }
}
