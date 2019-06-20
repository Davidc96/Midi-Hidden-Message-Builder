using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MHMBEncoder
{
    class MHMBEMain
    {
        private static string inputFile;
        private static string outputFile;
        private static int keyNoteOctave = EncoderDic.INIT_OCTAVE;

        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("MIDI HIDDEN MESSAGE BUILDER ENCODER");
            Console.WriteLine("---------------------------------------");

            if(ArgumentParser(args))
            {
                MIDIEncoder midiEncoder = new MIDIEncoder();
                string textToEncode = File.ReadAllText(inputFile);
                midiEncoder.Encode(textToEncode, outputFile , keyNoteOctave);
;
                Console.WriteLine("[INFO] File created!");
            }
            else
            {
                Console.WriteLine("[ERROR] Failed to parse arguments!");
                Console.WriteLine("[INFO] Usage MHMBEncoder.exe -i <fileText> -o <midiFile> [-k <keyNoteOctave>]");
            }
        }

        public static bool ArgumentParser(string[] args)
        {
            if(args.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < args.Length; i += 2)
            {
                string key = args[i];

                switch (key)
                {
                    case "-i":
                        inputFile = args[i + 1];
                        break;
                    case "-o":
                        outputFile = args[i + 1];
                        break;
                    case "-k":
                        keyNoteOctave = Convert.ToInt32(args[i + 1]);
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}
