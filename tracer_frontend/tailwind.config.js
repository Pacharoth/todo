/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
   
    extend: {
      animation:{
        fade:"fade 0.5s ease-in-out",
        fadeOut:"fadeOut 0.5s ease-in-out"
      },
      keyframes:{
        
        fade: {
          "0%": {
            opacity: "0",
          },
          '50%': {
            opacity: "0.5",
          },
          '100%': {
            opacity: "1",
          }
        },
        fadeOut:{
          "0%":{
            opacity:"1"
          },
          "50%":{
            opacity:"0.5"
          },
          "100%":{
            opacity:"0",
          }
        },
      },
    },
    
  },
  plugins: [],
}

