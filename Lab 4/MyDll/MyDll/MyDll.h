// MyDll.h - contains my own functions to work with
#pragma once

// MyLib gives you an opportunity to
// make math calculations using
// ready-to-use formulas
// SquareRect(a, b);
// SquareCircle(R);
// SquareEllipse(a, b);
// VolumeSphere(R);
// Volume2Base(height, a, b);
// Volume3Base(height, a, BaseHeight);
// Volume4Base(height, a, BaseHeight);

constexpr auto PI = 3.1415;

extern "C" __declspec(dllexport) float _cdecl SquareRect(float a, float b);

extern "C" __declspec(dllexport) float _cdecl SquareCircle(float R);

extern "C" __declspec(dllexport) float _cdecl SquareEllipse(float a, float b);

extern "C" __declspec(dllexport) float _cdecl VolumeSphere(float R);

extern "C" __declspec(dllexport) float _cdecl Volume2Base(float height, float a, float b);

extern "C" __declspec(dllexport) float _cdecl Volume3Base(float height, float a, float BaseHeight);

extern "C" __declspec(dllexport) float _cdecl Volume4Base(float height, float a, float BaseHeight);
