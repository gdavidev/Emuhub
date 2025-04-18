# ======= DEVELOPMENT STAGE ========
FROM node:20 AS development
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 5173
CMD ["npm", "run", "dev"]

# ======== PRODUCTION TARGET (BUILD) ========
FROM node:20 AS build
WORKDIR /app
COPY . .
RUN npm install && npm run build

# ======== PRODUCTION TARGET (SERVE) ========
FROM nginx:alpine AS production
COPY --from=build /app/dist /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 8080