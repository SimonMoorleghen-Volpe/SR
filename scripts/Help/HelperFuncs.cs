using System;

namespace HelperFuncs{
    public static class Help{
        public static bool CheckSign(double a, double b){
            if(Math.Sign(a) == Math.Sign(b)){
                return true;
            }
            return false;
        }
    }
}
