# CyVerse
CyVerse Coding Challenge
Please note: this code is not a functioning service.  Below are the analysis steps I was able to take, with a few hours of work effort, and no prior experience with rest services, nats.io, or Kubernetes/Containerized services.

Steps:
1)	Read up on Rest APIs, Nats.io and Kubernetes, learn about the overall system architecture.
Information on REST APIs:
https://www.pluralsight.com/blog/tutorials/representational-state-transfer-tips
Information on Nats.io:
https://docs.nats.io/nats-concepts/what-is-nats
Information on Kubernetes:
https://kubernetes.io/docs/concepts/overview/what-is-kubernetes/
2)	Download nats through visual studio, using NuGet
Look at example code, try to understand it, and try to get some code working.  For example, one resource used: https://github.com/nats-io/nats.net
3)	In this case, I attempted to set up a nats connection, publish an event, and subscribe to the event.
4)	I was not able to connect to nats (time out exception was thrown)

The code in Visual Studio Project taken from:
https://nats.io/blog/nats-in-dotnet/
