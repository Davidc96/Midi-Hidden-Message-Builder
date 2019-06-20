using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHMBEncoder
{
    class EncoderDic
    {
        public static int INIT_OCTAVE = 2;
        private static int MAX_OCTAVE = 11; //<-- DON'T TOUCH IT
         struct NoteOctave
        {
            public NoteName note;
            public int octave;
        }
        private Dictionary<char, NoteOctave> noteEncoderDictionary;

        public EncoderDic(int KeyNoteOctave)
        {
            noteEncoderDictionary = new Dictionary<char, NoteOctave>();
            InitDictionary(KeyNoteOctave);
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
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 1:
                        n.note = NoteName.CSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 2:
                        n.note = NoteName.D;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 3:
                        n.note = NoteName.DSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 4:
                        n.note = NoteName.E;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 5:
                        n.note = NoteName.F;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 6:
                        n.note = NoteName.FSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 7:
                        n.note = NoteName.G;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 8:
                        n.note = NoteName.GSharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 9:
                        n.note = NoteName.A;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 10:
                        n.note = NoteName.ASharp;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
                        break;
                    case 11:
                        n.note = NoteName.B;
                        n.octave = octaveCounter;
                        noteCounter++;
                        noteEncoderDictionary.Add(charset[i], n);
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

            Console.WriteLine("[INFO] Loaded Encoder Dictionary");
        }

        public NoteName GetNoteName(char ch)
        {
            return noteEncoderDictionary[ch].note;
        }

        public int GetOctave(char ch)
        {
            return noteEncoderDictionary[ch].octave;
        }


    }
}
