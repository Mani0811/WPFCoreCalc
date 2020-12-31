#include "pch.h"
#include < stdio.h > 
extern "C" {
    __declspec(dllexport) int add(int a, int b) {
        return a + b;
    }
}