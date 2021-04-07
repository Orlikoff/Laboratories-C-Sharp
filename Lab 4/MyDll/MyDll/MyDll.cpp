#include "pch.h"
#include <utility>
#include <limits.h>
#include "MyDll.h"

float _cdecl SquareRect(float a, float b) {
	return a * b;
}

float _cdecl SquareCircle(float R) {
	return PI * R * R;
}

float _cdecl SquareEllipse(float a, float b) {
	return a * b * PI;
}

float _cdecl VolumeSphere(float R) {
	return (4 * PI * R * R * R) / 3;
}

float _cdecl Volume2Base(float height, float a, float b) {
	return a * b * height;
}

float _cdecl Volume3Base(float height, float a, float BaseHeight) {
	return 0.5 * a * BaseHeight * height;
}

float _cdecl Volume4Base(float height, float a, float BaseHeight) {
	return a * BaseHeight * height;
}
