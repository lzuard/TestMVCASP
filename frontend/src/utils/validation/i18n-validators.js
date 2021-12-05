import * as validators from '@vuelidate/validators'
import { phone as rawPhone } from './customRules'
import i18n from '@/localization'

const { createI18nMessage } = validators
const { t } = i18n.global || i18n
const withI18nMessage = createI18nMessage({ t })

export const required = withI18nMessage(validators.required)
export const minLength = withI18nMessage(validators.minLength, { withArguments: true })
export const maxLength = withI18nMessage(validators.maxLength, { withArguments: true })
export const numeric = withI18nMessage(validators.numeric)
export const email = withI18nMessage(validators.email)
export const phone = withI18nMessage(rawPhone)
