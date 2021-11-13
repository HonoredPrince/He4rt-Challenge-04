FROM node:14.17.4
WORKDIR /app
COPY [".env", "package-lock.json", "package.json",  "./"]
RUN npm install --production
COPY . .
EXPOSE 80
CMD ["npm", "start"]
