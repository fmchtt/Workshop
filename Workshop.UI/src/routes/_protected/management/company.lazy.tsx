import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/_protected/management/company')({
  component: () => <div>Hello /_protected/management/company!</div>
})