#include <fstream>
#include <iostream>

#define size 1024
#define PI 3.14159265

using namespace std;

ifstream fin("in1.txt");
ofstream fout("points.txt");

double points;
double fs;
double Ts;
double t;
double w1;

int main()
{
	points = size;
	fs = 5000;
	Ts = 1/fs;
	t = 0;
	w1 = 2 * PI * 60;

    for(int i=0; i<size; i++)
    {                                      
        //fout<<t<<"\t"<<(6.0*sin(w1*t) + 3.0*sin(10*w1*t) + 1.5*sin(20*w1*t))<<endl;
		//fout<<t<<"\t"<<(6.0*sin(w1*t) + 3.0*sin(10*w1*t))<<endl;
		fout<<"1651 4 000 0 00"<<endl;
		fout<<(6.0*sin(w1*t) + 3.0*sin(10*w1*t))<<endl;
		t = t + Ts;
	}

    return 0;
}