# Whitepages Pro Code Examples in C# [![Build Status](https://travis-ci.org/whitepages/pro-examples-csharp.svg?branch=master)](https://travis-ci.org/whitepages/pro-examples-csharp)


Use mcs and mono to compile and run C# sources on Mac OS X. Install mono and [nuget.sh].

## Install

Install [Newtonsoft.Json]:

```shell
nuget.sh install Newtonsoft.Json -Version 8.0.3
```

## Compile

Compile the sources:

```shell
mcs -r:/path/to/Newtonsoft.Json.dll,System.Web.dll,System.Net.Http.dll IdentityCheck.cs
mcs -r:/path/to/Newtonsoft.Json.dll,System.Web.dll,System.Net.Http.dll LeadVerify.cs
```

## Run

Run the code with mono:

```shell
mono LeadVerify.exe
mono IdentityCheck.exe
```

[nuget.sh]: https://gist.github.com/andypiper/2636885
[Newtonsoft.Json]: http://www.newtonsoft.com/json
