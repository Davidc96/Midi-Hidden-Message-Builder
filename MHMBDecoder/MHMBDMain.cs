using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHMBDecoder
{
    class MHMBDMain
    {
        private static string midiFile = "";
        private static int keyNoteOctave = DecoderDic.INIT_OCTAVE;
        static void Main(string[] args)
        {
            MIDIDecoder midiDecoder = new MIDIDecoder();
            if(ArgumentParser(args))
            {
                midiDecoder.Decode(midiFile, keyNoteOctave);
               // midiDecoder.Decode("eva.mid", 3);
            }
            else
            {
                Console.WriteLine("[ERROR] Failed to parse arguments!");
                Console.WriteLine("[INFO] Usage MHMBDecoder.exe -i <midifile> [-k <keyNoteOctave>]");
            }
        }

        public static bool ArgumentParser(string[] args)
        {
            
            for(int i = 0; i < args.Length; i+=2)
            {
                string key = args[i];
                
                switch(key)
                {
                    case "-i":
                        midiFile = args[i + 1];
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
