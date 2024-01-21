FROM node:18-alpine

WORKDIR /reactapp

COPY package.json /reactapp/
COPY package-lock.json /reactapp/

RUN npm ci

COPY . .

EXPOSE 3000

CMD ["npm", "start"]
