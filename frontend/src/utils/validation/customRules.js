import { helpers } from '@vuelidate/validators'

const PHONE_REGEXP = /^\+7\([0-9]{3}\)[0-9]{3}-[0-9]{2}-[0-9]{2}$/g

export const phone = helpers.regex(PHONE_REGEXP)
