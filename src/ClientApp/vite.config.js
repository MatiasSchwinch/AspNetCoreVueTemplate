import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import mkcert from 'vite-plugin-mkcert'
import { fileURLToPath, URL } from 'node:url'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [vue(), mkcert()],
    server: {
        port: 3000,
        https: true,
        strictPort: true,
        proxy: {
            '/api': {
                target: 'https://localhost:44338',
                changeOrigin: true,
                secure: false,
                rewrite: (path) => path.replace(/^\/api/, '/api')
            },
            '/docs': {
                target: 'https://localhost:44338',
                changeOrigin: true,
                secure: false,
                rewrite: (path) => path.replace(/^\/docs/, '/docs')
            }
        }
    },
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    }
})
