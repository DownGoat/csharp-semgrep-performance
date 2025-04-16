# C# Performance Improvement Rules

A collection of [semgrep](https://semgrep.dev/) rules for detecting easy-to-fix performance improvements in C# code.

## 🚀 Overview

This repository contains semgrep rules designed to catch small but impactful performance issues in C# codebases. While individual improvements might seem minor, collectively they can significantly enhance application performance and development experience.

As developers, we spend countless hours running, debugging, and testing our code. When our applications run faster, we spend less time waiting and more time doing what we love, writing code. These rules aim to eliminate those small delays that disrupt our workflow and make development less enjoyable.

## 🔍 What This Project Covers

This project focuses on easy-to-implement performance optimizations, particularly targeting:

- Reducing unnecessary allocations to minimize Garbage Collection pressure
- Replacing inefficient patterns with more performant alternatives
- Identifying common C# performance pitfalls that are easy to overlook

## 📁 Repository Structure

```
├── performance/         # Main directory containing all semgrep rules
│   ├── rule-category-1/ # Rules grouped by category 
│   ├── rule-category-2/
│   └── tests/           # Test .cs files to validate rules
├── Benchmarks/          # .NET Benchmark project
└── README.md
```

## 🔧 How It Works

Each rule in the repository:

1. Identifies a specific performance anti-pattern in C# code
2. Is accompanied by tests that validate the rule works correctly
3. Has corresponding benchmarks showing the performance difference between the problematic and optimized versions

## 📊 Benchmarks

The repository includes a .NET Benchmark project that demonstrates the performance impact of each issue the rules detect. The benchmarks:

- Provide concrete evidence of performance improvements
- Compare the problematic code against the optimized solution
- Help quantify the impact of seemingly small optimizations

## 🧰 Using These Rules

### Prerequisites

- [Install semgrep](https://semgrep.dev/docs/getting-started/)


## 🤝 Contributing

Contributions are welcome! If you have ideas for new rules or improvements to existing ones:

1. Fork the repository
2. Create a new branch for your changes
3. Add your rule with corresponding tests and benchmarks
4. Submit a pull request

## 📖 Why Performance Matters

Performance isn't just about making users happy—it makes our lives as developers better too. In a typical development day, we're constantly running code, debugging, testing, and repeating the cycle. When code runs faster, we spend less time waiting and more time actually coding.

Nobody enjoys staring at a spinning wheel while tests run or the debugger loads. Those small delays disrupt our flow and make development less enjoyable.

Many performance issues in C# applications come from the "death of a thousand cuts" - small inefficiencies that add up. Garbage Collection can be particularly impactful, which is why many rules focus on alternatives that require fewer or no allocations.

## 📝 License

[Choose your license and add it here]