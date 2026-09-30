FROM ollama/ollama

#docker build to create the docker image and then appand docker container.

#Add correct model
RUN ollama serve & sleep 5 && ollama pull llama3.2 && pkill ollama

#fix command for thinkingmode of 
CMD ["ollama", "serve"]

