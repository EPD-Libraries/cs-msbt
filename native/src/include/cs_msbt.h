#pragma once

#include <msbt/msbt.h>

#include "native.h"

using namespace oepd;

EXP msbt::MSBT* FromBinary(u8* src, size_t src_len);
EXP std::vector<u8>* ToBinary(msbt::MSBT* handle);

EXP msbt::MSBT* FromText(const char* text);
EXP std::string* ToText(msbt::MSBT* handle);

EXP bool Free(msbt::MSBT* handle);