import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;

public class Aks_new {

    // if n is any number, then it is prime if,
    //( x – 1 )^n – ( x^n – 1) is divisible by n

    static class GFG {
        // array used to store coefficients .
        static BigInteger c[] = new BigInteger[10000];


        // function to calculate the coefficients
        // of (x - 1)^n - (x^n - 1) with the help
        // of Pascal's triangle .
        static void coef(int n) {
            c[0] = BigInteger.valueOf(1);
            for (int i = 0; i < n; c[0] = c[0].multiply(BigInteger.valueOf(-1)), i++) {
                c[1 + i] = BigInteger.valueOf(1);
                for (int j = i; j > 0; j--)
                    c[j] = c[j - 1].subtract(c[j]);
            }
        }

        //All coeff divisible by n
        static boolean test(int n) {

            // Calculating all the coefficients by
            // the function coef and storing all
            // the coefficients in c array .
            coef(n);

            // subtracting c[n] and adding c[0] by 1
            // as ( x - 1 )^n - ( x^n - 1), here we
            // are subtracting c[n] by 1 and adding
            // 1 in expression.
            c[0] = c[0].add(BigInteger.valueOf(1));
            c[n] = c[n].subtract(BigInteger.valueOf(1));

            // checking all the coefficients whether
            // they are divisible by n or not.
            // if n is not prime, then loop breaks
            // and (i > 0).
            int i = n;
            while ((i--) > 0 && c[i].mod(BigInteger.valueOf(n)).equals(BigInteger.valueOf(0))) ;

            // Return true if all coefficients are
            // divisible by n.
            return i < 0;
        }

        public static void main(String[] args) throws IOException {
            BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

            System.out.print("Enter digit: ");
            int n = 1;
            while ((n = Integer.parseInt(br.readLine())) != 0) {
                if (test(n))
                    System.out.println("Prime");
                else
                    System.out.println("Not Prime");
                System.out.print("Enter digit: ");
            }
        }
    }
}